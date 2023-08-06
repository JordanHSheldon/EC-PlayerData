provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "acr_rg" {
  name     = "EsportsCompareRG"
  location = "East US"
}

resource "azurerm_container_registry" "acr" {
  name                     = "EsportsCompareACR"
  resource_group_name      = azurerm_resource_group.acr_rg.name
  location                 = azurerm_resource_group.acr_rg.location
  sku                      = "Basic"  # Change this to your desired SKU
  admin_enabled            = true
}

resource "azurerm_container_group" "aci" {
  name                = "EsportsCompareACG"
  location            = azurerm_resource_group.acr_rg.location
  resource_group_name = azurerm_resource_group.acr_rg.name
  os_type = "Linux"

  container {
    name   = "STDATA"
    image  = "${azurerm_container_registry.acr.login_server}/STDATA:latest" 
    cpu    = "0.5"
    memory = "1.5"

    environment_variables = {
      KEY1 = "VALUE1",
      KEY2 = "VALUE2",
    }

    ports {
      port     = 80
      protocol = "TCP"
    }
  }
}

#terraform init
#terraform apply