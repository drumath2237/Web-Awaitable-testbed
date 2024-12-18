mergeInto(LibraryManager.library, {
    getStringJSAsync: async function(callbackPtr) {
        await new Promise(resolve=>setTimeout(resolve, 5000));
        Module.dynCall_v(callbackPtr);
    }
})
