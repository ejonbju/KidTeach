var common = {

    // From a image list, select a set of 'nrOfImages' random elements
    selectImageList : function(imageList, nrOfImages) 
    {
        var selectedRandomImages = [];

        while (selectedRandomImages.length < nrOfImages) {
            var image = imageList[common.getRandom(imageList.length)];

            if (!common.internal.doesListContainWord(selectedRandomImages, image)) {
                selectedRandomImages.push(image);
            }
        }

        return selectedRandomImages;
    },

    // random from 0 to topLimit
    getRandom: function (topLimit)
    {
        return Math.floor((Math.random() * topLimit));
    },

    wordToSentence : function(word) 
    {
        return word.split("_").join("  ");
    },

    sentenceToWord : function(sentence) 
    {
        return sentence.split("  ").join("_");
    },


    animation : {

        JippiImageFromLeft : function (aniationCompleteFunction)
        {
            $("#jippi_bild").css("visibility", "visible");
            $("#jippi_bild").animate({ left: "600px" }, 2000, "", function () {
                setTimeout(function () {
                        $("#jippi_bild").css("visibility", "hidden"); $("#jippi_bild").css("left", "0");

                    aniationCompleteFunction();

                }, 1000);
            });
        },

        JippiImageJump : function (aniationCompleteFunction)
        {
            $("#jippi_bild").css("visibility", "visible").css("top", "500px");

            $("#jippi_bild").animate({ left: "300px", top: "0px" }, 1000).animate({ left: "600px", top: "300px" }, 2000, "", function () {
                setTimeout(function () {
                    $("#jippi_bild").css("visibility", "hidden"); $("#jippi_bild").css("left", "0px").css("top", "500px");

                    aniationCompleteFunction();

                }, 2000);

            });
        }
    }, // end animation





    // "Private" functions
    internal: {

        doesListContainWord: function (listToSearch, wordToFind) {
            for (var i = 0; i < listToSearch.length; i++) {
                if (listToSearch[i] == wordToFind) {
                    return true;
                }
            }

            return false;
        }
    } // end internal
    

};