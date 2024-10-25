function playSound() {
    var audio = document.getElementById('soundAudio');
    if (audio) {
        audio.play().catch(function (error) {
            console.log("Reprodução de som bloqueada. Interação do usuário é necessária.");
        });
    } else {
        console.log("Elemento de áudio não encontrado.");
    }
}