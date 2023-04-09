mergeInto(LibraryManager.library, {

  ScrollDownGameDetail: function (number) {

    // let contentSectionToGo;

    switch(number) {
        case 1:
            // contentSectionToGo = document.getElementById("content_slugan1");
            window.scrollBy(0, 800);
            break;
        case 2:
            // contentSectionToGo = document.getElementById("content_slugan2");
            window.scrollBy(0, 1450);
            break;
        case 3:
            // contentSectionToGo = document.getElementById("content_slugan3");
            window.scrollBy(0, 2100);
            break;
        case 4:
            // contentSectionToGo = document.getElementById("content_slugan4");
            window.scrollBy(0, 2750);
            break;
        case 5:
            // contentSectionToGo = document.getElementById("content_ruckster");
            window.scrollBy(0, 3400);
            break;
        default:
            // contentSectionToGo = document.getElementById("unity-container");
            window.scrollBy(0, 650);
    }
    
    // contentSectionToGo.scrollIntoView(true);
    
  },

});