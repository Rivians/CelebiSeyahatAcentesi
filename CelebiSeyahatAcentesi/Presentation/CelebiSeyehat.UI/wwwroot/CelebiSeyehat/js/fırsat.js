document.addEventListener('DOMContentLoaded', () => {
    // Butonlar
    const yurtDisiBtn = document.getElementById('btn-yurt-disi');
    const yurtIciBtn = document.getElementById('btn-yurt-ici');
    const contentArea = document.getElementById('firsatUcuslariContent');

    // Butonlara tıklama eventi ekle
    yurtDisiBtn.addEventListener('click', () => {
        // Butonları aktif yap
        yurtDisiBtn.classList.add('active');
        yurtIciBtn.classList.remove('active');
        
        // İçeriği güncelle
        updateContent('yurt-disi');
    });

    yurtIciBtn.addEventListener('click', () => {
        // Butonları aktif yap
        yurtIciBtn.classList.add('active');
        yurtDisiBtn.classList.remove('active');
        
        // İçeriği güncelle
        updateContent('yurt-ici');
    });

    // İçeriği güncelleme fonksiyonu
    function updateContent(type) {
        let html = '';

        // Yurt dışı içeriği
        if (type === 'yurt-disi') {
            html = `
                <div class="col">
                    <div class="card h-100">
                        <img src="/CelebiSeyehat/img/londra.jpg" class="card-img-top" alt="London">
                        <div class="card-body">
                            <h5 class="card-title">Londra</h5>
                            <p class="card-text">Yurt dışı fırsat uçuşları.</p>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card h-100">
                        <img src="/CelebiSeyehat/img/paaris.jpg" class="card-img-top" alt="Paris">
                        <div class="card-body">
                            <h5 class="card-title">Paris</h5>
                            <p class="card-text">Yurt dışı fırsat uçuşları.</p>
                        </div>
                    </div>
                </div>
            `;
        }
        // Yurt içi içeriği
        else if (type === 'yurt-ici') {
            html = `
                <div class="col">
                    <div class="card h-100">
                        <img src="/CelebiSeyehat/img/İstanbul.jpg" class="card-img-top" alt="Istanbul">
                        <div class="card-body">
                            <h5 class="card-title">İstanbul</h5>
                            <p class="card-text">Yurt içi fırsat uçuşları.</p>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card h-100">
                        <img src="/CelebiSeyehat/img/Antalya.jpg" class="card-img-top" alt="Antalya">
                        <div class="card-body">
                            <h5 class="card-title">Antalya</h5>
                            <p class="card-text">Yurt içi fırsat uçuşları.</p>
                        </div>
                    </div>
                </div>
            `;
        }

        // Yeni içeriği ekle
        contentArea.innerHTML = html;
    }

    // Sayfa yüklendiğinde varsayılan olarak Yurt Dışı içeriği göster
    updateContent('yurt-disi');
});
