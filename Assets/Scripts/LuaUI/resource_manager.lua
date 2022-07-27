local _Class = require("Base/base_class")

local ResourceManager = ResourceManager or Extends(_Class)

function ResourceManager.Load(path)
    return CS.ResourceTool.LoadGameObject(path)
end

function ResourceManager.Instantiate(gameobj,transform)
    return CS.UnityEngine.Object.Instantiate(gameobj,transform)
end

function ResourceManager.LoadAndInstantiate(path,transform)
    local gameobject = CS.ResourceTool.LoadGameObject(path)
    return CS.UnityEngine.Object.Instantiate(gameobject,transform)
end

function ResourceManager.FindGameObject(name)
    return CS.UnityEngine.GameObject.FindGameObjectWithTag(name)
end

function ResourceManager.FindGameObjects(name)
    return CS.UnityEngine.GameObject.FindGameObjectsWithTag(name)
end

function ResourceManager.Destroy(obj)
    CS.UnityEngine.GameObject.Destroy(obj)
end

return ResourceManager