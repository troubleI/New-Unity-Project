local _Singleton = require("Base/singleton_base")
local _PanelManager = require("Panel/panel_manager")
local _WindowManager = require("Window/window_manager")

-- panel主页面
_Singleton.Instance(_PanelManager):AddPanel("UI/PanelMain","PanelMain","PanelManager")
-- 主页面button
_Singleton.Instance(_PanelManager):AddButton("PanelMain","Panel1_btn","ClickPanel","Panel1")
_Singleton.Instance(_PanelManager):AddButton("PanelMain","Panel2_btn","ClickPanel","Panel2")
_Singleton.Instance(_PanelManager):AddButton("PanelMain","Panel3_btn","ClickPanel","Panel3")
-- 注册其他panel
_Singleton.Instance(_PanelManager):AddPanel("UI/Panel1","Panel1","PanelManager")
_Singleton.Instance(_PanelManager):AddPanel("UI/Panel2","Panel2","PanelManager")
_Singleton.Instance(_PanelManager):AddPanel("UI/Panel3","Panel3","PanelManager")
-- 打开主页面
_Singleton.Instance(_PanelManager):ClickPanel("PanelMain")

-- Window主页面
_Singleton.Instance(_WindowManager):AddWindow("UI/WindowMain","WindowMain","WindowManager")
_Singleton.Instance(_WindowManager):AddButton("WindowMain","win1_btn","ClickWindow","win1")
-- Window1
_Singleton.Instance(_WindowManager):AddWindow("UI/win1","win1","WindowManager")
_Singleton.Instance(_WindowManager):AddButton("win1","win2_btn","ClickWindow","win2")
_Singleton.Instance(_WindowManager):AddButton("win1","win3_btn","ClickWindow","win3")
_Singleton.Instance(_WindowManager):AddButton("win1","Back_btn","BackBtn")
-- Window2
_Singleton.Instance(_WindowManager):AddWindow("UI/win2","win2","WindowManager")
_Singleton.Instance(_WindowManager):AddButton("win2","win3_btn","ClickWindow","win3")
_Singleton.Instance(_WindowManager):AddButton("win2","Back_btn","BackBtn")
-- Window3
_Singleton.Instance(_WindowManager):AddWindow("UI/win3","win3","WindowManager")
_Singleton.Instance(_WindowManager):AddButton("win3","Back_btn","BackBtn")
-- 打开主页面
_Singleton.Instance(_WindowManager):ClickWindow("WindowMain")