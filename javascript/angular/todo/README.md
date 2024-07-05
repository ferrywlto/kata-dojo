# Todo

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 18.0.6.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

## Angular Notes

### Using form
- Need to import `ReactiveFormsModule` in the component file that use [formControl] directive in template

### Form vaildations

- 2 appraoches
    - Template based -> like `v-model` in Vue
        - Asynchorous data flow
        - Mutable 2-way bindings properties
        - Less efficient in chagne detection and tracking, poor rendering performance
        - Harder to test as rendering and passage of time included
    - Reactive form based
        - Synchoruous data flow, more safe
        - Functional paradigm, immutable data
        - Better rendering performance
        - Test is straight forward


## Features
- [ ] Prioritization: Allow users to set priorities for tasks (e.g., high, medium, low).
- [ ] Categories/Tags: Users can categorize or tag tasks for better organization.
Due Dates and Reminders: Enable setting due dates for tasks and sending reminders.
- [ ] Recurring Tasks: Support for tasks that recur daily, weekly, monthly, etc.
- [ ] Subtasks: Break tasks into smaller, manageable subtasks.
- [ ] Notes and Attachments: Allow adding notes and attachments to tasks for more context.
- [ ] Search and Filter: Implement search functionality and filters by priority, due date, category, etc.
- [ ] Collaboration: Share tasks or lists with others and collaborate in real-time.
- [ ] Progress Tracking: Visual indicators or progress bars for task completion.
- [ ] Dark Mode: Provide a dark mode option for the user interface.
- [ ] Export/Import Tasks: Allow users to export and import their tasks.
- [ ] Integration with Calendars: Sync tasks with external calendar apps.
- [ ] - [ ] Customizable Themes: Offer theme customization options for personalization.
- [ ] Voice Commands: Add tasks and manage them through voice commands.
- [ ] Analytics and Insights: Provide insights on task completion rates, productivity trends, etc.
- [ ] Undo/Redo Actions: Allow users to undo or redo their recent actions.
- [ ] Task History: Keep a history log of all changes made to tasks.
- [ ] Location-based Reminders: Remind users of tasks when they are at specific locations.
- [ ] Keyboard Shortcuts: Implement keyboard shortcuts for common actions to enhance usability.
- [ ] API for Third-party Integrations: Provide an API for integration with other apps and services.

### Client side only
- [ ] Offline Support: Implement service workers for offline access to the app and tasks.
- [ ] Local Storage: Use local storage or IndexedDB to save tasks directly in the user's browser.
- [ ] Drag and Drop: Allow users to reorder tasks and categories through drag and drop.
- [ ] Pomodoro Timer: Integrate a Pomodoro timer to help users focus on tasks for short intervals.
- [ ] Markdown Support: Enable markdown formatting in task descriptions for better readability.
- [ ] Task Timer: Allow users to set a timer for individual tasks to track time spent.
- [ ] Light/Dark Mode Toggle: Provide a toggle switch for users to switch between light and dark modes.
- [ ] Customizable Dashboard: Let users customize the layout of their todo list dashboard.
- [ ] Browser Notifications: Use browser notification API for reminders and alerts.
- [ ] Quick Add Widget: Implement a quick add widget or popup to easily add tasks from any page.
- [ ] Keyboard Navigation: Enhance usability with comprehensive keyboard shortcuts for task management.
- [ ] Task Templates: Offer pre-defined templates for common task types or projects.
- [ ] Batch Operations: Enable batch actions for tasks, such as marking multiple tasks as completed or deleting them.
- [ ] Printable Lists: Provide a print-friendly view of todo lists for physical backup or task management.
- [ ] Import from CSV/JSON: Allow users to import tasks from CSV or JSON files.
- [ ] Export to CSV/JSON: Enable exporting tasks to CSV or JSON for backup or use in other applications.
- [ ] Task Sorting: Offer sorting options for tasks by priority, due date, creation date, etc.
- [ ] Visual Themes: Provide a selection of visual themes beyond just light and dark mode.
- [ ] Language Support: Add support for multiple languages to make the app accessible to a wider audience.
- [ ] Accessibility Features: Ensure the app is accessible, supporting screen readers, keyboard navigation, and providing sufficient contrast.