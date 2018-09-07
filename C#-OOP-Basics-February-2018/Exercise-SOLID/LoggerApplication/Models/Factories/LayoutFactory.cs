using LoggerApplication.Models.Interfaces;
using System;

namespace LoggerApplication.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout Create(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}