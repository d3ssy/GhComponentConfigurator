using System;
using System.Collections.Generic;
using System.Text;
using System.Xaml;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GrasshopperComponentConfigurator.Models
{
    public class ComponentData : ObservableObject
    {
        private string _nameSpace = "MyComponentNamespace";
        private List<ParamData> _parameters = new List<ParamData>();
        private string _name = "MyComponentName";
        private string _nickname = "MyComponentNickname";
        private string _category = "MyComponentCategory";
        private string _subCategory = "MyComponentSubCategory";
        private string _description = "Description";

        public string Namespace
        {
            get => _nameSpace;
            set => SetProperty(ref _nameSpace, value);
        }

        public List<ParamData> Parameters
        {
            get => _parameters;
            set => SetProperty(ref _parameters, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Nickname
        {
            get => _nickname;
            set => SetProperty(ref _nickname, value);
        }

        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public string SubCategory
        {
            get => _subCategory;
            set => SetProperty(ref _subCategory, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
