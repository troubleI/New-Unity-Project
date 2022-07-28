local _BaseView = require("Base/base_view")

local PanelView = PanelView or Extends(_BaseView)

function PanelView:ClickPanel(name)
    self.parent_manager:ClickPanel(name)
end

return PanelView