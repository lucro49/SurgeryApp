import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-patients-card',
  templateUrl: './patients-card.component.html',
  styleUrls: ['./patients-card.component.css']
})
export class PatientsCardComponent implements OnInit {
@Input() user: User;
  constructor() { }

  ngOnInit() {
  }

}
