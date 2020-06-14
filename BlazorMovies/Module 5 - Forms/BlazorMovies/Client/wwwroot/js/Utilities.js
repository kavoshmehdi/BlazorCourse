function my_function(message) {
    console.log("from utilities " + message);
}
function dotnetStaticInvokation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCounter")
        .then(result => {
            console.log("counter from javascript : " + result);
        });
}
function dotnetInstanceInvokation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}
function setFocus(element) {
    element.focus();
}