// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

/* validación tamaño de la foto y vista previa */
function sizeAndPreviewPhoto() {
  const $img = document.getElementById("preview");
  const $input = document.getElementById("foto");
  $input.addEventListener('change', () => {
    if ($input.files[0].size > 50000) {
      alert("Archivo demasiado grande");
      $input.value = "";
    } else if ($input.files[0]) {
      const reader = new FileReader();
      reader.onload = function (e) {
        $img.setAttribute('src', e.target.result);
      }
      reader.readAsDataURL($input.files[0]);
    }
  })
}
sizeAndPreviewPhoto();

/* validación tamaño de los documentos */
function sizeDocuments() {
  const $input = document.getElementById("uploads");
  $input.addEventListener('change', () => {
    if ($input.files[0].size > 300000) {
      alert("Archivo demasiado grande");
      $input.value = ""
    }
  })
}
sizeDocuments();

/* capturar foto usando API web nativa */
function webcam() {
  const $player = document.getElementById('player');
  const $captureButton = document.getElementById('capture');
  const $snapshotCanvas = document.getElementById('snapshot');

  $player.classList.remove('d-none');
  $captureButton.classList.remove('d-none');

  navigator.mediaDevices.getUserMedia({ video: true })
    .then((stream) => $player.srcObject = stream)
    .catch(() => alert('Se necesitan permisos para acceder a la cámara'));

  $captureButton.addEventListener('click', () => {
    $snapshotCanvas.classList.remove('d-none');
    const context = $snapshotCanvas.getContext('2d', { alpha: false });
    context.drawImage($player, 0, 0, $snapshotCanvas.width, $snapshotCanvas.height);
    document.getElementById('preview').src = $snapshotCanvas.toDataURL();
  })
}
document.getElementById('showCamara').addEventListener('click', () => webcam());