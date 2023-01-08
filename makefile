PROJECT_NAME := exta
TAG_PREFIX := registry.annium.com/$(PROJECT_NAME)
TFM := net7.0
BIN_DEBUG := bin/Debug/$(TFM)

configure:
	@# infrastructure
	$(call copy,docker,db.env,run/db)
	$(call copy,local,db.yml,server/src/Server.Db.Migrator/configuration)

	@# server
	$(call copy,docker,db.yml,run/server/configuration)
	$(call copy,local,db.yml,server/src/Server.Host/configuration)
	$(call copy,shared,host.yml,run/server/configuration server/src/Server.Host/configuration)

	@# site
	$(call copy,shared,site.yml,web/src/Site/configuration)

deconfigure:
	rm -rf run
	$(call clean,*/src/,/configuration/)

publish: publish-server publish-site

publish-server:
	$(call publish,server,.,server/src/Server.Host/app.dockerfile)

publish-site:
	$(call publish,site,.,web/src/Site/app.dockerfile)

# infra targets

migrate:
	cd server/src/Server.Db.Migrator && dotnet run

db-drop:
	docker-compose rm -vfs db
	docker volume rm -f exta_db
	docker-compose up -d db

# control
define copy
	$(foreach dir,$(3),mkdir -p $(dir);$(foreach file,$(2),cp cfg/$(1)/$(file) $(dir);))
endef

define clean
	$(foreach folder,$(1),$(foreach pattern,$(2),git ls-files --others $(folder) | grep $(pattern) | xargs rm -f;))
endef

define publish
	@$(eval image := $(1))
	@$(eval context := $(2))
	@$(eval dockerfile := $(3))
	@docker build -t $(TAG_PREFIX)/$(image) -f $(context)/$(dockerfile) $(context)
	@docker push $(TAG_PREFIX)/$(image)
endef

.PHONY: $(MAKECMDGOALS)