import { Component, OnInit } from '@angular/core';

import { Organization } from '../../models';
import { OrganizationService } from '../shared';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss']
})
export class OrganizationComponent implements OnInit {

  organization: Organization;

  constructor(private readonly _service: OrganizationService) { }

  ngOnInit() {
  }

}
