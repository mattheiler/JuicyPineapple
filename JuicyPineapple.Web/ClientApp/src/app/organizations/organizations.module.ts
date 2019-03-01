import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrganizationsRoutingModule } from './organizations-routing.module';

import { OrganizationComponent } from './organization';
import { OrganizationListComponent } from './organization-list';
import { OrganizationService } from './shared';

@NgModule({
  declarations: [OrganizationListComponent, OrganizationComponent],
  imports: [CommonModule, OrganizationsRoutingModule],
  providers: [OrganizationService]
})
export class OrganizationsModule {
}
