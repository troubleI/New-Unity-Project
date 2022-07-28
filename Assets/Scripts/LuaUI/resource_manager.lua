local _Class = require("Base/base_class")

local ResourceManager = ResourceManager or Extends(_Class)

function ResourceManager.Load(path)
    return CS.UnityEngine.Resources.Load(path,typeof(CS.UnityEngine.GameObject))
end

function ResourceManager.Instantiate(gameobj,transform)
    return CS.UnityEngine.Object.Instantiate(gameobj,transform)
end

function ResourceManager.FindGameObject(name)
    return CS.UnityEngine.GameObject.Find(name)
end

function ResourceManager.TransformFind(gameobject,name)
    return gameobject.transform:Find(name)
end

function ResourceManager.Destroy(obj)
    CS.UnityEngine.GameObject.Destroy(obj)
end

return ResourceManager