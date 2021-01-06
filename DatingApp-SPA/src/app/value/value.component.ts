import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.scss']
})
export class ValueComponent implements OnInit {

  constructor(private http: HttpClient) { }
  values: any;
  ngOnInit() {
    this.load();
  }

  load(){
    this.http.get('http://localhost:5000/api/values').subscribe(
      data => {
        this.values = data;
      }, error => {
        console.log(error);
      }
    );
    console.log(this.values);
  }



}
