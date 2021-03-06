﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePerfabSystem : ViewSystemBase
{

    public override void Init()
    {
        AddEntityDestroyLisnter();
    }

    public override Type[] GetFilter()
    {
        return new Type[] { typeof(AssetComponent)};
    }

    public override void Update(int deltaTime)
    {
        List<EntityBase> list = GetEntityList();
        for (int i = 0; i < list.Count; i++)
        {
            if(!list[i].GetExistComp<PerfabComponent>())
            {
                PerfabComponent comp = list[i].AddComp<PerfabComponent>();
                comp.perfab = GameObjectManager.CreateGameObject(list[i].GetComp<AssetComponent>().m_assetName);
            }
        }
    }

    public override void OnEntityDestroy(EntityBase entity)
    {
        if (entity.GetExistComp<PerfabComponent>())
        {
            PerfabComponent pc = entity.GetComp<PerfabComponent>();
            GameObjectManager.DestroyGameObjectByPool(pc.perfab);
        }
    }
}
