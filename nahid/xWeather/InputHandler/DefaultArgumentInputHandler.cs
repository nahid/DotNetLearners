using System;
using xWeather.InputHandler.IPToGeo;

namespace xWeather.InputHandler
{
    public class DefaultArgumentInputHandler(string[] args) : IInputHandler
    {
        private readonly string[] _args = args;

        public string GetLocation()
        {
            var location = "";
            if (_args.Length == 0 || _args[0] == "-p" || _args[0] == "--p")
            {
                Task<Response> response = IPToGeoInformation.GetDefaultLocation();
                if(response != null){
                    location = response.Result.City;
                }
            }
            else if (_args[0] != "-p" && _args[0] != "--p")
            {
                location = _args[0].Trim();
            }

            return location;
        }

        public string GetProvider()
        {
            string provider = "weatherapi";
            if (_args.Length > 0)
            {
                if (_args[0] == "-p" || _args[0] == "--p")
                {
                    if (_args.Length > 1 && _args[1] != null)
                    {
                        provider = _args[1].Trim();
                    }
                }
                else
                {
                    if(_args.Length > 1 && (_args[1] == "-p" || _args[1] == "--p")){
                        if (_args.Length > 2 && _args[2] != null)
                        {
                           provider = _args[2].Trim();
                        }
                    }
                }
            }

            return provider;
        }
    }
}