mergeInto(LibraryManager.library, {
    getStringJSAsync: async function(callbackPtr) {
        await new Promise(resolve=>setTimeout(resolve, 3000));
        Module.dynCall_v(callbackPtr);
    }
})
