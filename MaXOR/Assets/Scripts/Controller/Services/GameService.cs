using Maxor.Model;
using Maxor.Model.Tree;
using Maxor.Views;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service
{
    public interface IGameService
    {
        void StartLevel(JSONLevelValues values);
        void StartLevel(string values);
    }

    public class GameService : IGameService
    {
        private IServices services;
        private IReferences references;

        private List<IInputNumber> inputNumbers;

        public GameService(IServices services,IReferences references)
        {
            this.services = services;
            this.references = references;
            inputNumbers = new List<IInputNumber>();
        }

        public void StartLevel(string values)
        {
            StartLevel(Deserialize(values));
        }

        public void StartLevel(JSONLevelValues values)
        {
            RootNode rootNode = services.TreeCreatorService.GetTreeRoot(values.rootNode);
            services.UiTreeCreator.Create(rootNode);

            for(int i =0; i< values.inputNumbers.Length; i++)
            {
                IInputNumber number = services.PrefabsService.Get<InputNumber, IInputNumber>(references.WorldReferences.InputNumberContainer.transform);
                number.Init(references.WorldReferences.Canva.transform, services.InputNumberDropService, values.inputNumbers[i]);
                inputNumbers.Add(number);
            }

        }

        private JSONLevelValues Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<JSONLevelValues>(json);
        }

    }
}

