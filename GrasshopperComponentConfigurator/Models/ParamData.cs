using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GrasshopperComponentConfigurator.Models
{
    public class ParamData : ObservableObject
    {
        private ParamType _paramType = ParamType.Generic;
        private Usage _usage = Usage.Input;
        private ParamAccess _access = ParamAccess.Item;
        private string _name = "ParamName";
        private string _nickname = "ParamNickName";
        private string _description = "ParamDescription";

        public ParamType ParamType
        {
            get => _paramType;
            set => SetProperty(ref _paramType, value);
        }

        public Usage Usage
        {
            get => _usage;
            set => SetProperty(ref _usage, value);
        }

        public ParamAccess Access
        {
            get => _access;
            set => SetProperty(ref _access, value);
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

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}