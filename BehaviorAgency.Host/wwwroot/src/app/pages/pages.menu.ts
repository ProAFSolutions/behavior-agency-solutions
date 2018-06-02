import { NbMenuItem } from '@nebular/theme';


export const AgencyMenuItems : NbMenuItem[] = [
  {
    title: 'Dashboard',
    icon: 'nb-home',
    link: '/examples/dashboard',
    home: true,
  },
  {
    title: 'Clients',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'RBTs',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'Analyst',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'Cases',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'Reports',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
];

export const RBTMenuItems : NbMenuItem[] = [
  {
    title: 'Dashboard',
    icon: 'nb-home',
    link: '/examples/dashboard',
    home: true,
  },
  {
    title: 'My Clients',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'My Cases',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'Contact Information',
    icon: 'nb-location',
    link: '/examples/maps/gmaps'
  },
  {
    title: 'Work',
    group: true,
  },
  {
    title: 'Documents',
    icon: 'nb-compose',    
    children: [
      {
        title: 'Employment Authorization',
        link: '/examples/forms/inputs',
      },
      {
        title: 'In-Services & Training',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Certificates',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Resume & Mental Health Experience',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Attestation Form',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Background Screening',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Background check',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Reminders',
        link: '/examples/forms/layouts',
      }
    ],
  },
  {
    title: 'Company',
    icon: 'nb-compose',    
    children: [
      {
        title: 'Tax ID & Company Info',
        link: '/examples/forms/inputs',
      },
      {
        title: 'Company Docs',
        link: '/examples/forms/layouts',
      }
    ],
  },
  {
    title: 'Auto & Insurances',
    icon: 'nb-compose',    
    children: [
      {
        title: 'Car Information',
        link: '/examples/forms/inputs',
      },
      {
        title: 'Car Insurance',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Other Insurances',
        link: '/examples/forms/layouts',
      }
    ],
  },
  {
    title: 'Data Collection',
    icon: 'nb-compose',    
    children: [
      {
        title: 'Daily Progress Notes',
        link: '/examples/forms/inputs',
      },
      {
        title: 'Frequency Datasheet',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Monthly Report',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Replacement Record',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Caregiver Competency Check',
        link: '/examples/forms/layouts',
      },
      {
        title: 'Services Timesheet',
        link: '/examples/forms/layouts',
      }
    ],
  }
];

