document.addEventListener('DOMContentLoaded', () => {
    const buttons = document.querySelectorAll('.button-group .btn');
    const searchCard = document.getElementById('searchCard');

    buttons.forEach(button => {
        button.addEventListener('click', (event) => {
            event.preventDefault();
            const type = button.getAttribute('data-type');
            updateSearchCard(type);
        });
    });

    

    // `searchCard`'ı güncelleyen fonksiyon
    function updateSearchCard(type) {
        let content = '';
        switch (type) {
            case 'ucak': // Uçak bileti arama
                content = `
                    <div id="searchCard" class="row search-card ">
                <div class="col-md-3 mb-3 ">
                    <label for="nereden" class="form-label">Nereden</label>
                    <input type="text" id="nereden" class="form-control" placeholder="Şehir veya havaalanı">
                </div>
                <div class="col-md-3 mb-3">
                    <label for="nereye" class="form-label">Nereye</label>
                    <input type="text" id="nereye" class="form-control" placeholder="Şehir veya havaalanı">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="tarih" class="form-label">Gidiş Tarihi</label>
                    <input type="date" id="tarih" class="form-control">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="yolcuSayisi" class="form-label">Yolcu Sayısı</label>
                    <select id="yolcuSayisi" class="form-select">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                    </select>
                </div>
                <div class="col-md-2 d-flex align-items-center">
                    <button class="btn btn-primary w-100">Uçak Bileti Bul</button>
                </div>
                
            </div>
                `;
                break;
            case 'otel': // Otel arama
                content = `
                    <div id="searchCard" class="row search-card ">
                <div class="col-md-3 mb-3 ">
                    <label for="konum">Konum</label><br>
                    <input type="text" id="konum" placeholder="Örn: Antalya">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="tarih" class="form-label">Giriş Tarihi</label>
                    <input type="date" id="tarih" class="form-control">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="tarih" class="form-label">Çıkış Tarihi</label>
                    <input type="date" id="tarih" class="form-control">
                </div>
                <div class="col-md-3 mb-3">
                    <label for="yolcuSayisi" class="form-label">Ziyaretçi Sayısı</label>
                    <select id="yolcuSayisi" class="form-select">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                    </select>
                </div>
               
                <div class="col-md-2  d-flex align-items-center">
                    <button class="btn btn-primary w-100">Otel Bul</button>
                </div>
                
                
            </div>
                `;
                break;
            case 'otobus': // Otobüs bileti arama
                content = `
                <div id="searchCard" class="row search-card ">
                <div class="col-md-3 mb-3 ">
                    <label for="nereden" class="form-label">Nereden</label>
                    <input type="text" id="nereden" class="form-control" placeholder="Şehir">
                </div>
                <div class="col-md-3 mb-3">
                    <label for="nereye" class="form-label">Nereye</label>
                    <input type="text" id="nereye" class="form-control" placeholder="Şehir">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="tarih" class="form-label">Gidiş Tarihi</label>
                    <input type="date" id="tarih" class="form-control">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="yolcuSayisi" class="form-label">Yolcu Sayısı</label>
                    <select id="yolcuSayisi" class="form-select">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                    </select>
                </div>
                <div class="col-md-2 d-flex align-items-center">
                    <button class="btn btn-primary w-100">Otobüs Bileti Bul</button>
                </div>
                
            </div>
                `;
                break;
            
            case 'tren': // Tren bileti arama
                content = `
                       <div id="searchCard" class="row search-card ">
                <div class="col-md-3 mb-3 ">
                    <label for="nereden" class="form-label">Nereden</label>
                    <input type="text" id="nereden" class="form-control" placeholder="Şehir">
                </div>
                <div class="col-md-3 mb-3">
                    <label for="nereye" class="form-label">Nereye</label>
                    <input type="text" id="nereye" class="form-control" placeholder="Şehir">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="tarih" class="form-label">Gidiş Tarihi</label>
                    <input type="date" id="tarih" class="form-control">
                </div>
                <div class="col-md-2 mb-3">
                    <label for="yolcuSayisi" class="form-label">Yolcu Sayısı</label>
                    <select id="yolcuSayisi" class="form-select">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                    </select>
                </div>
                <div class="col-md-2 d-flex align-items-center">
                    <button class="btn btn-primary w-100">Tren Bileti Bul</button>
                </div>
                
            </div>
                `;
                break;
                
            default:
                content = `<p>Lütfen bir arama türü seçin.</p>`;
                break;
        }
    
        // İçeriği güncelle
        searchCard.innerHTML = content;
    }
});
