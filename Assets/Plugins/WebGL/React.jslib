mergeInto(LibraryManager.library, {
    SetStart: function () {
    window.dispatchReactUnityEvent("SetStart");
  },

  EnterMain: function () {
    window.dispatchReactUnityEvent("EnterMain");
  },

  ScoreToStars: function (score) {
    window.dispatchReactUnityEvent("ScoreToStars", score);
  },
  
});