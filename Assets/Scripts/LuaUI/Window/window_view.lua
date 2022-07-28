local _BaseView = require("Base/base_view")

local WindowView = WindowView or Extends(_BaseView)

function WindowView:ClickWindow(name)
    self.parent_manager:ClickWindow(name)
end

function WindowView:BackBtn()
    self.parent_manager:BackBtn()
end

return WindowView