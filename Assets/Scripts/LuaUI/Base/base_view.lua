local _Class = require("Base/base_class")
local _ResourceManager = require("resource_manager")

local BaseView = BaseView or Extends(_Class)

BaseView.parent_manager = false;
--存放button与其参数
BaseView.btn_list = {}
BaseView.btn_parameter = {}
--对应unity的ui
BaseView.ui_object = false
BaseView.now_ui = false
BaseView.parent_transform = false

function BaseView:SetUI(path,transform,parent)
    local ui = _ResourceManager.Load(path)
    self.ui_object = ui
    self.parent_transform = transform
    self.parent_manager = parent
end

function BaseView:AddBtn(name,func,...)
    self.btn_list[name] = func
    self.btn_parameter[name] = ...
end

-- 初始化button
function BaseView:InitBtn()
    --优化只查找自己下的物体
    for k, v in pairs(self.btn_list) do
        local btn = _ResourceManager.TransformFind(self.now_ui,k)
        btn:GetComponent("Button").onClick:AddListener(function ()
            self[v](self,self.btn_parameter[k])
        end)
    end
end

-- 判断对应panel是否存在
function BaseView:IsActive()
    return self.now_ui
end

function BaseView:OnEnable()
    self.now_ui = _ResourceManager.Instantiate(self.ui_object,self.parent_transform)
    self:InitBtn()
end

function BaseView:OnDisable()
    if self.now_ui then
        _ResourceManager.Destroy(self.now_ui)
        self.now_ui = false 
    end
end

return BaseView