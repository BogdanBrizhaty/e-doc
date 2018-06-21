using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Managers.ContextState
{
    /// <summary>
    /// Interface for any operational state holder, like Session or Cookies
    /// </summary>
    public interface IContextStateManager
    {
        void AddOrUpdateItem(string key, object value);
        object GetItem(string key);
        //TType GetItem<TType>(string key);
        bool ItemExists(string key);
        void RemoveItem(string key);
    }
}
