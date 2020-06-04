mergeInto(LibraryManager.library, {

  KAPIInit: function () {
    if(typeof(kongregateUnitySupport) != 'undefined'){
        kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');
      };
  },

  SubmitKongStat: function (StatName, StatValue) {
    kongregate.stats.submit(Pointer_stringify(StatName), StatValue);
  }

});