local _Class = require("Base/base_class")

local WindowView = WindowView or Extends(_Class)

WindowView.window_object = false

function WindowView:SetWindow(window)
    self.window_object = window
end

function WindowView:OnEnable()
    self.window_object:SetActive(true) 
end

function WindowView:OnDisable()
    self.window_object:SetActive(false) 
end

return WindowView