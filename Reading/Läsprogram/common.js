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

    fileNameToWord : function(fileName)
    {
        var word = fileName.split(".")[0];
        word = word.toUpperCase();
        //word = word.toLowerCase();
        return word;
    },



    animation : {

        ImageFromLeft : function(imageId,leftDestination, aniationCompleteFunction)
        {
            $(imageId).css("left", "0");
            $(imageId).css("visibility", "visible");
            $(imageId).animate({ left: leftDestination }, 1000, "", aniationCompleteFunction);
        },

        ImageFromRight: function (imageId, leftDestination, aniationCompleteFunction) {
            $(imageId).css("left", "1000px");
            $(imageId).css("visibility", "visible");
            $(imageId).animate({ left: leftDestination }, 1000, "", aniationCompleteFunction);
        },


        JippiImageFromLeft : function (aniationCompleteFunction)
        {
            common.animation.ImageFromLeft("#jippi_bild","600px",

                function () {
                    setTimeout(function () {
                  //  $("#jippi_bild").css("left", "0");
                    $("#jippi_bild").css("visibility", "hidden"); 

                    aniationCompleteFunction();

                }, 1000);
            })

            /*
            $("#jippi_bild").css("visibility", "visible");

            $("#jippi_bild").animate({ left: "600px" }, 2000, "", function () {
                setTimeout(function () {
                        $("#jippi_bild").css("visibility", "hidden"); $("#jippi_bild").css("left", "0");

                    aniationCompleteFunction();

                }, 1000);
            });*/
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