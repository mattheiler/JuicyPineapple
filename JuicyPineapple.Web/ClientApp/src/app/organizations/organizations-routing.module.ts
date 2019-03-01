import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrganizationComponent } from './organization';
import { OrganizationListComponent } from './organization-list';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: OrganizationListComponent,
  },
  {
    path: ':id',
    pathMatch: 'full',
    component: OrganizationComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationsRoutingModule { }
