window.jsFunctions = {
    setImageUsingStreaming: async function setImageUsingStreaming(dotnetRef, overlayId, imageId, imageStream) {
        const arrayBuffer = await imageStream.arrayBuffer();
        const blob = new Blob([arrayBuffer]);
        const url = URL.createObjectURL(blob);
        document.getElementById(imageId).src = url;
        document.getElementById(imageId).style.display = 'block';
        initOverlay(document.getElementById(overlayId));
        if (reader) {
            reader.maxCvsSideLength = 9999
            decodeImage(dotnetRef, url, blob);
        }

    },
    initSDK: async function () {
        if (reader != null) {
            return true;
        }
        let result = true;
        try {
            reader = await Dynamsoft.DBR.BarcodeReader.createInstance();
            await reader.updateRuntimeSettings("balance");
        } catch (e) {
            console.log(e);
            result = false;
        }
        return result;
    },
    initScanner: async function (dotnetRef, videoId, selectId, overlayId) {
        let canvas = document.getElementById(overlayId);
        initOverlay(canvas);
        videoSelect = document.getElementById(selectId);
        videoSelect.onchange = openCamera;
        dotnetHelper = dotnetRef;

        try {
            scanner = await Dynamsoft.DBR.BarcodeScanner.createInstance();
            await scanner.setUIElement(document.getElementById(videoId));
            await scanner.updateRuntimeSettings("speed");

            let cameras = await scanner.getAllCameras();
            listCameras(cameras);
            await openCamera();
            scanner.onFrameRead = results => {
                showResults(results);
            };
            scanner.onUnduplicatedRead = (txt, result) => { };
            scanner.onPlayed = function () {
                updateResolution();
            }
            await scanner.show();

        } catch (e) {
            console.log(e);
            result = false;
        }
        return true;
    },
};