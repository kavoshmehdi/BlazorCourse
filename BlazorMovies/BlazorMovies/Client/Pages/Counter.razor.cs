using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorMovies.Client.Shared.MainLayout;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton { get; set; }
        [Inject] TransientService transient { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [CascadingParameter] public AppState AppState { get; set; }
        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public  async Task IncrementCount()
        {
            currentCount++;
            singleton.Value = currentCount;
            transient.Value = currentCount;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvokation");
        }
        public async Task IncrementCountJavascript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvokation",
                DotNetObjectReference.Create(this));
        }
        [JSInvokable]
        public static Task<int> GetCounter()
        {
            return Task.FromResult(currentCountStatic);
        }

    }
}
