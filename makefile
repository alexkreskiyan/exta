PROJECT_NAME := exta
TAG_PREFIX := registry.annium.com/$(PROJECT_NAME)
TFM := netcoreapp3.1
BIN_DEBUG := bin/Debug/$(TFM)

publish: publish-api publish-site

publish-api:
	$(call publish,api,.,src/api/Exta.Api/app.dockerfile)

publish-site:
	$(call publish,site,.,src/site/Exta.Site/app.dockerfile)

start-api:
	$(call start-dotnet,core,Exta.Api,8101)

stop: stop-api

stop-api:
	$(call stop-dotnet,Exta.Api)

# control
define start-dotnet
	@$(eval component := $(1))
	@$(eval project := $(2))
	@$(eval port := $(3))
	cd src/$(component)/$(project) && dotnet $(BIN_DEBUG)/$(project).dll -port $(port) &
endef

define stop-dotnet
	@$(eval project := $(1))
	ps -ax | grep $(project).dll | grep -v src | grep -v grep | sed -e 's#^ *##' | cut -d ' ' -f 1 | xargs -I% kill %
endef

define publish
	@$(eval image := $(1))
	@$(eval context := $(2))
	@$(eval dockerfile := $(3))
	@docker build -t $(TAG_PREFIX)/$(image) -f $(context)/$(dockerfile) $(context)
	@docker push $(TAG_PREFIX)/$(image)
endef

.PHONY: $(MAKECMDGOALS)