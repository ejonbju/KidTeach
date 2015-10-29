var common = {

    getRandom: function (lowValue, topValue)
    {
        return lowValue + Math.round((Math.random() * (topValue - lowValue)));
    },

    getRandomImageFromList : function (imageList)
    {
        var imageIndex = common.getRandom(0, imageList.length - 1);
        var selectedImage = imageList[imageIndex];

        return selectedImage;
    }
}