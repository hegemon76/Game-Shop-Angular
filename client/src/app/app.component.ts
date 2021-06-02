import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';

  constructor(private http: HttpClient) {}

  ngOnInit() :void {

    this.http.get('https://localhost:5001/api/videogames/search/?PageSize=10&PageNumber=1').subscribe((response: any) =>{
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

}
