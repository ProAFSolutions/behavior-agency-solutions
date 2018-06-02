import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Dashboard',
    icon: 'nb-home',
    link: '/examples/dashboard',
    home: true,
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'UI Features',
    icon: 'nb-keypad',
    link: '/examples/ui-features',
    children: [
      {
        title: 'Buttons',
        link: '/examples/ui-features/buttons',
      },
      {
        title: 'Grid',
        link: '/examples/ui-features/grid',
      },
      {
        title: 'Icons',
        link: '/examples/ui-features/icons',
      },
      {
        title: 'Modals',
        link: '/examples/ui-features/modals',
      },
      {
        title: 'Popovers',
        link: '/examples/ui-features/popovers',
      },
      {
        title: 'Typography',
        link: '/examples/ui-features/typography',
      },
      {
        title: 'Animated Searches',
        link: '/examples/ui-features/search-fields',
      },
      {
        title: 'Tabs',
        link: '/examples/ui-features/tabs',
      },
    ],
  },
  {
    title: 'Forms',
    icon: 'nb-compose',
    children: [
      {
        title: 'Form Inputs',
        link: '/examples/forms/inputs',
      },
      {
        title: 'Form Layouts',
        link: '/examples/forms/layouts',
      },
    ],
  },
  {
    title: 'Components',
    icon: 'nb-gear',
    children: [
      {
        title: 'Tree',
        link: '/examples/components/tree',
      }, {
        title: 'Notifications',
        link: '/examples/components/notifications',
      },
    ],
  },
  {
    title: 'Maps',
    icon: 'nb-location',
    children: [
      {
        title: 'Google Maps',
        link: '/examples/maps/gmaps',
      },
      {
        title: 'Leaflet Maps',
        link: '/examples/maps/leaflet',
      },
      {
        title: 'Bubble Maps',
        link: '/examples/maps/bubble',
      },
      {
        title: 'Search Maps',
        link: '/examples/maps/searchmap',
      },
    ],
  },
  {
    title: 'Charts',
    icon: 'nb-bar-chart',
    children: [
      {
        title: 'Echarts',
        link: '/examples/charts/echarts',
      },
      {
        title: 'Charts.js',
        link: '/examples/charts/chartjs',
      },
      {
        title: 'D3',
        link: '/examples/charts/d3',
      },
    ],
  },
  {
    title: 'Editors',
    icon: 'nb-title',
    children: [
      {
        title: 'TinyMCE',
        link: '/examples/editors/tinymce',
      },
      {
        title: 'CKEditor',
        link: '/examples/editors/ckeditor',
      },
    ],
  },
  {
    title: 'Tables',
    icon: 'nb-tables',
    children: [
      {
        title: 'Smart Table',
        link: '/examples/tables/smart-table',
      },
    ],
  },
  {
    title: 'Miscellaneous',
    icon: 'nb-shuffle',
    children: [
      {
        title: '404',
        link: '/pages/miscellaneous/404',
      },
    ],
  },
  {
    title: 'Auth',
    icon: 'nb-locked',
    children: [
      {
        title: 'Login',
        link: '/auth/login',
      },
      {
        title: 'Register',
        link: '/auth/register',
      },
      {
        title: 'Request Password',
        link: '/auth/request-password',
      },
      {
        title: 'Reset Password',
        link: '/auth/reset-password',
      },
    ],
  },
];
