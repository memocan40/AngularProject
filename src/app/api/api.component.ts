import { Component } from '@angular/core';

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.css']
})
export class ApiComponent {

  apiResponse: any[] | undefined;
  parameter: any;
  async submitForm(event: Event) {

    event.preventDefault(); // Verhindert das Neuladen der Seite bei Formulareinsendung

    fetch('https://api.imgflip.com/get_memes')
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log(data); // Verarbeiten der empfangenen Daten
      this.apiResponse=data.data.memes

    })
    .catch(error => {
      console.error('Error:', error);
    });
  }
}
