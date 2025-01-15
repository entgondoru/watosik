// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showImage(imageId) {
    // Ukryj wszystkie obrazki
    const images = document.querySelectorAll('.image');
    images.forEach(image => {
        image.style.display = 'none'; // Ukrywa wszystkie obrazki
    });

    // Pokaż wybrany obrazek
    const selectedImage = document.getElementById(imageId);
    if (selectedImage) {
        selectedImage.style.display = 'block'; // Pokazuje wybrany obrazek
    }
}
document.getElementById('canteenSelect').addEventListener('change', updateMeals);
document.getElementById('datePicker').addEventListener('change', updateMeals);

function updateMeals() {
    const canteenId = document.getElementById('canteenSelect').value;
    const date = document.getElementById('datePicker').value;

    fetch(`/Canteen/GetMealsByCanteenAndDate?canteenId=${canteenId}&date=${date}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Błąd podczas ładowania danych!');
            }
            return response.json();
        })
        .then(data => {
            const tableBody = document.getElementById('canteenTableBody');
            tableBody.innerHTML = ''; // Wyczyść zawartość tabeli

            if (data && data.length > 0) {
                data.forEach(meal => {
                    const row = `
                                <tr>
                                    <td>${meal.breakfast || 'Brak danych'}</td>
                                    <td>${meal.dinner || 'Brak danych'}</td>
                                    <td>${meal.supper || 'Brak danych'}</td>
                                </tr>`;
                    tableBody.innerHTML += row;
                });
            } else {
                tableBody.innerHTML = '<tr><td colspan="3">Brak danych w jadłospisie.</td></tr>';
            }
        })
        .catch(error => {
            console.error('Wystąpił błąd:', error);
            alert('Nie udało się załadować danych!');
        });
}

// Automatyczne ładowanie danych dla domyślnej stołówki i daty po załadowaniu strony
document.addEventListener('DOMContentLoaded', () => {
    updateMeals();
});

document.addEventListener('DOMContentLoaded', updateMeals);