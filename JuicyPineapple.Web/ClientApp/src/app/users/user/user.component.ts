import { Component, OnInit } from '@angular/core';

import { User } from '../../models';
import { UserService } from '../shared';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  organizations: Promise<User>;

  constructor(private readonly _service: UserService) {}

  ngOnInit() {
  }

}
