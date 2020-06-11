using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Client.Helpers
{
    public static class IJSRuntimeExtentions
    {
        public static ValueTask SaveAs(this IJSRuntime js, string fileName, byte[] content)
        {
            return js.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(content));
        }
        public static ValueTask DisplaeMessage(this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync("Swal.fire", message);
        }
        public static ValueTask DisplaeMessage(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeVoidAsync("Swal.fire", title, message, sweetAlertMessageType.ToString());
        }
        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, sweetAlertMessageType.ToString());
        }
        public static ValueTask AlertMessage(this IJSRuntime js,SweetPosition sweetPosition, string title, int time)
        {
            return js.InvokeVoidAsync("CustomPosition",GetDescription(sweetPosition) , title, time);
        }
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        //public static string GetDescription(Enum value)
        //{
        //    return
        //        value
        //            .GetType()
        //            .GetMember(value.ToString())
        //            .FirstOrDefault()
        //            ?.GetCustomAttribute<DescriptionAttribute>()
        //            ?.Description
        //        ?? value.ToString();
        //}
        public static ValueTask SetInLocalStorage(this IJSRuntime js,string key,string content)=>
            js.InvokeVoidAsync("localStorage.setItem", key, content);
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key) =>
            js.InvokeAsync<string>("localStorage.getItem", key);
        public static ValueTask RemoveItem(this IJSRuntime js, string key) =>
            js.InvokeVoidAsync("localStorage.removeItem", key);
    }
    public enum SweetAlertMessageType
    {
        question, warning, error, success, info
    }
    public enum SweetPosition
    {
        [Description("top")]
        top,
        [Description("top-start")]
        top_start,
        [Description("top-end")]
        top_end,
        [Description("center")]
        center,
        [Description("center-start")]
        center_start,
        [Description("center-end")]
        center_end,
        [Description("bottom")]
        bottom,
        [Description("bottom-start")]
        bottom_start,
        [Description("bottom-end")]
        bottom_end
    }
}
