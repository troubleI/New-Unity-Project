local BaseInterface = BaseInterface or {}

function BaseInterface.__print()
    CS.UnityEngine.Debug.LogError("Error: function is not implemented!")
end

return BaseInterface