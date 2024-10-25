window.startQuagga = (dotNetObject) => {
    navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
            // Verifica se as permissões da câmera foram concedidas
            console.log('Permissão de câmera concedida.');

            navigator.mediaDevices.enumerateDevices().then(devices => {
                const videoDevices = devices.filter(device => device.kind === 'videoinput');
                if (videoDevices.length === 0) {
                    alert("Nenhuma câmera detectada.");
                    return;
                }

                Quagga.init({
                    inputStream: {
                        name: "Live",
                        type: "LiveStream",
                        target: document.querySelector('#barcode-reader'),
                        constraints: {
                            width: 640,
                            height: 480,
                            facingMode: "environment" // Câmera traseira
                        }
                    },
                    decoder: {
                        readers: ["code_128_reader"] // Tipo de código de barras
                    }
                }, function (err) {
                    if (err) {
                        console.log("Erro ao inicializar Quagga: ", err);
                        alert("Não foi possível iniciar o leitor de código de barras. Verifique se a câmera está disponível.");
                        return;
                    }
                    console.log("Quagga inicializado com sucesso.");
                    Quagga.start();
                });

                let lastDetectedCode = null;

                Quagga.onDetected((data) => {
                    const code = data.codeResult.code;

                    if (code !== lastDetectedCode) {
                        lastDetectedCode = code;
                        console.log("Código detectado: " + code);
                        dotNetObject.invokeMethodAsync('OnBarcodeDetected', code);

                        // Evita que o mesmo código seja lido repetidamente
                        setTimeout(() => lastDetectedCode = null, 2000); // Evita leitura duplicada por 2 segundos
                    }
                });
            }).catch(error => {
                console.log("Erro ao acessar dispositivos de mídia: ", error);
                alert("Erro ao acessar a câmera. Verifique as permissões.");
            });
        })
        .catch(err => {
            console.error("Erro ao acessar a câmera: ", err);
            alert("Permissão de câmera negada.");
        });
}
