mergeInto(LibraryManager.library, {

  ScrollDownGameDetail: function (number) {

    // let contentSectionToGo;

    switch(number) {
        case 1:
            // contentSectionToGo = document.getElementById("content_slugan1");
            window.scrollBy(0, 300);
            break;
        case 2:
            // contentSectionToGo = document.getElementById("content_slugan2");
            window.scrollBy(0, 600);
            break;
        case 3:
            // contentSectionToGo = document.getElementById("content_slugan3");
            window.scrollBy(0, 900);
            break;
        case 4:
            // contentSectionToGo = document.getElementById("content_slugan4");
            window.scrollBy(0, 1200);
            break;
        case 5:
            // contentSectionToGo = document.getElementById("content_ruckster");
            window.scrollBy(0, 1500);
            break;
        default:
            // contentSectionToGo = document.getElementById("unity-container");
            window.scrollBy(0, 0);
    }
    
    // contentSectionToGo.scrollIntoView(true);
    
  },

});