import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html',
  styleUrls: ['./patient-detail.component.css']
})
export class PatientDetailComponent implements OnInit {
@Input() user: User;

  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.LoadUsers();
  }

  LoadUsers() {
    this.userService.getUser(+this.route.snapshot.params.id).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error(error);
    });
  }

}
