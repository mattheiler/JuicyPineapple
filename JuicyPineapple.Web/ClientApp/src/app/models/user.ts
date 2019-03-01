import { OrganizationMembership } from './organization-membership';

export class User {
  id: string;
  name: string;
  organizations: OrganizationMembership[];
}
