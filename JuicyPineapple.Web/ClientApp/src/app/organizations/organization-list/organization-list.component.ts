import { Component, OnInit } from '@angular/core';

import { Organization } from '../../models';
import { OrganizationService } from '../shared';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.scss']
})
export class OrganizationListComponent implements OnInit {

  organizations: Promise<Organization[]>;

  constructor(private readonly _service: OrganizationService) {}

  ngOnInit() {
    this.organizations = this._service.getOrganizations();
  }

}
