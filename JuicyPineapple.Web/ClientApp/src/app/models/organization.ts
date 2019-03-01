import { OrganizationMembership } from './organization-membership';

export class Organization {
  id: string;
  name: string;
  parent: Organization;
  parentId?: string;
  children: Organization[];
  users: OrganizationMembership[];
}
