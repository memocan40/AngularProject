import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css'],
})
export class ServerComponent {
  myForm: FormGroup;
  inputText: string | undefined;

  constructor(private http: HttpClient, private formBuilder: FormBuilder) {
    this.myForm = this.formBuilder.group({
      inputText: ''
    });
  }

  onSubmit() {
    const inputTextValue = this.myForm.value.inputText;
    this.http.get('http://localhost:5057/api/getdata').subscribe(response => {
      console.log(response); // Hier kannst du die Antwort weiterverarbeiten
    });
  }

  onPost(event: Event) {
    event.preventDefault(); // Verhindert das Standardverhalten des Formulars (Neuladen der Seite)

    const body = { param: this.inputText };
    console.log(1111, body.param)
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
    this.http.post('http://localhost:5057/api/Post', body, httpOptions).subscribe(
      response => {
        console.log('POST-Anfrage erfolgreich verarbeitet', response);
        // Weitere Verarbeitung der Antwort hier
      },
      error => {
        console.error('Fehler beim Verarbeiten der POST-Anfrage', error);
      }
    );
  }
}
