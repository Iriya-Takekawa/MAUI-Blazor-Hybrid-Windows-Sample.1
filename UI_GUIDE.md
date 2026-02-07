# UI Screenshots and Visual Guide

This document describes the expected UI layout and functionality of the MAUI Blazor Hybrid Windows Sample application.

## Application Layout

The application uses a standard sidebar navigation layout with the following components:

### Main Layout
```
┌─────────────────────────────────────────────────────────────────┐
│  ┌─────────────┬──────────────────────────────────────────────┐ │
│  │             │  Top Bar                     │  About        │ │
│  │  Sidebar    ├──────────────────────────────────────────────┤ │
│  │  Navigation │                                               │ │
│  │             │                                               │ │
│  │  • Home     │         Main Content Area                     │ │
│  │  • Categories│         (Page Components)                   │ │
│  │  • Items    │                                               │ │
│  │  • Export/  │                                               │ │
│  │    Import   │                                               │ │
│  │  • Report   │                                               │ │
│  │  • Excel    │                                               │ │
│  │    Definition│                                              │ │
│  │             │                                               │ │
│  └─────────────┴───────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────┘
```

## Page Layouts

### 1. Home Page

**Route**: `/`

**Layout**:
```
┌─────────────────────────────────────────────────────────────┐
│  MAUI Blazor Hybrid Sample                                  │
│                                                              │
│  Welcome to the MAUI Blazor Hybrid Windows Sample          │
│  application!                                                │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Features                                               ││
│  │ • Categories: Manage product categories               ││
│  │ • Items: Manage items with category association       ││
│  │ • Export/Import: Backup and restore database          ││
│  │ • Report: View report template information            ││
│  │ • Excel Definition: View database schema definition   ││
│  └────────────────────────────────────────────────────────┘│
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Database Information                                   ││
│  │ Database Location: C:\Users\...\LocalState\app.db      ││
│  │ Status: Initialized                                    ││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### 2. Categories Page

**Route**: `/categories`

**Layout (List View)**:
```
┌─────────────────────────────────────────────────────────────┐
│  Categories                                                  │
│                                                              │
│  [Add New Category]                                          │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ ID │ Code    │ Name            │ Actions             ││
│  ├────┼─────────┼─────────────────┼─────────────────────┤│
│  │ 1  │ CAT001  │ Electronics     │ [Edit] [Delete]     ││
│  │ 2  │ CAT002  │ Books           │ [Edit] [Delete]     ││
│  │ 3  │ CAT003  │ Office Supplies │ [Edit] [Delete]     ││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

**Layout (Add/Edit Form)**:
```
┌─────────────────────────────────────────────────────────────┐
│  Categories                                                  │
│                                                              │
│  [Add New Category]                                          │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Add Category                                           ││
│  │                                                         ││
│  │ Code:                                                   ││
│  │ [________________]                                      ││
│  │                                                         ││
│  │ Name:                                                   ││
│  │ [________________]                                      ││
│  │                                                         ││
│  │ [Save]  [Cancel]                                        ││
│  └────────────────────────────────────────────────────────┘│
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ ID │ Code    │ Name            │ Actions             ││
│  │ ...                                                     ││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### 3. Items Page

**Route**: `/items`

**Layout (List View)**:
```
┌─────────────────────────────────────────────────────────────────────────┐
│  Items                                                                   │
│                                                                          │
│  [Add New Item]                                                          │
│                                                                          │
│  ┌──────────────────────────────────────────────────────────────────┐ │
│  │ID│Code   │Name        │Category │Amount  │Note         │Actions││ │
│  ├──┼───────┼────────────┼─────────┼────────┼─────────────┼───────┤│ │
│  │1 │ITEM001│Laptop      │Electronics│$1,200.00│High-perf..│[E][D]││ │
│  │2 │ITEM002│Prog. Book  │Books     │$45.99   │C# prog... │[E][D]││ │
│  │3 │ITEM003│Notebook    │Office..  │$5.50    │A4 ruled.. │[E][D]││ │
│  └──────────────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────────────┘
```

**Layout (Add/Edit Form)**:
```
┌─────────────────────────────────────────────────────────────┐
│  Items                                                       │
│                                                              │
│  [Add New Item]                                              │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Add Item                                               ││
│  │                                                         ││
│  │ Code:                                                   ││
│  │ [________________]                                      ││
│  │                                                         ││
│  │ Name:                                                   ││
│  │ [________________]                                      ││
│  │                                                         ││
│  │ Category:                                               ││
│  │ [▼ Select Category   ]                                  ││
│  │    - Electronics                                        ││
│  │    - Books                                              ││
│  │    - Office Supplies                                    ││
│  │                                                         ││
│  │ Amount:                                                 ││
│  │ [________________]                                      ││
│  │                                                         ││
│  │ Note:                                                   ││
│  │ [_________________________________]                     ││
│  │ [_________________________________]                     ││
│  │ [_________________________________]                     ││
│  │                                                         ││
│  │ [Save]  [Cancel]                                        ││
│  └────────────────────────────────────────────────────────┘│
│                                                              │
│  [Table with existing items...]                             │
└─────────────────────────────────────────────────────────────┘
```

### 4. Export/Import Page

**Route**: `/export-import`

**Layout**:
```
┌─────────────────────────────────────────────────────────────┐
│  Export/Import Database                                      │
│                                                              │
│  ┌───────────────────────┬───────────────────────────────┐ │
│  │ Export Database       │ Import Database               │ │
│  │                       │                               │ │
│  │ Export the current    │ Import database from a ZIP    │ │
│  │ database to a ZIP file│ file.                         │ │
│  │                       │                               │ │
│  │ Export Location:      │ ZIP File Path:                │ │
│  │ C:\Users\...\         │ [________________________]    │ │
│  │ Documents\            │                               │ │
│  │ MauiBlazorApp_Exports │                               │ │
│  │                       │                               │ │
│  │ [Export Now]          │ [Import Now]                  │ │
│  └───────────────────────┴───────────────────────────────┘ │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ SUCCESS: Database exported to                          ││
│  │ C:\Users\...\database_export_20260207_042407.zip       ││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### 5. Report Page

**Route**: `/report`

**Layout**:
```
┌─────────────────────────────────────────────────────────────┐
│  Report Template                                             │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Report Information                                     ││
│  │                                                         ││
│  │ Template Path:                                          ││
│  │ C:\Users\...\AppData\Local\Packages\...\ReportTemplate.│
│  │ xlsx                                                    ││
│  │                                                         ││
│  │ Template Status: ✓ Found                                ││
│  │                                                         ││
│  │ ┌────────────────────────────────────────────────────┐││
│  │ │ Note:                                              │││
│  │ │ This is a dummy report service implementation.     │││
│  │ │ In production, this would integrate with AS-Report │││
│  │ │ or SpreadsheetGear for actual report generation.   │││
│  │ │                                                     │││
│  │ │ The IReportService interface allows for easy       │││
│  │ │ replacement with the actual implementation.        │││
│  │ └────────────────────────────────────────────────────┘││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### 6. Excel Definition Page

**Route**: `/definition`

**Layout**:
```
┌─────────────────────────────────────────────────────────────┐
│  Excel Definition (DataModel.xlsx)                           │
│                                                              │
│  [Load Definition]                                           │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐│
│  │ Definition Content                                     ││
│  │                                                         ││
│  │ DataModel.xlsx loaded successfully from                 ││
│  │ C:\Users\...\AppData\Local\Packages\...\DataModel.xlsx ││
│  │                                                         ││
│  │ Found 2 table(s):                                       ││
│  │                                                         ││
│  │ Table: Categories                                       ││
│  │   Columns (3):                                          ││
│  │     - Id (INTEGER) [Required]                           ││
│  │     - Code (TEXT) [Required] [MaxLength: 50]            ││
│  │     - Name (TEXT) [Required] [MaxLength: 200]           ││
│  │                                                         ││
│  │ Table: Items                                            ││
│  │   Columns (6):                                          ││
│  │     - Id (INTEGER) [Required]                           ││
│  │     - Code (TEXT) [Required] [MaxLength: 50]            ││
│  │     - Name (TEXT) [Required] [MaxLength: 200]           ││
│  │     - CategoryId (INTEGER) [Required]                   ││
│  │     - Amount (DECIMAL)                                  ││
│  │     - Note (TEXT) [MaxLength: 500]                      ││
│  └────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

## Color Scheme

The application uses the following color scheme (from Resources/Styles/Colors.xaml):

- **Primary Color**: #512BD4 (Purple)
- **Secondary Color**: #DFD8F7 (Light Purple)
- **Tertiary Color**: #2B0B98 (Dark Purple)
- **Background**: White (#FFFFFF)
- **Sidebar**: Gradient from #052767 to #3a0647

## Typography

- **Font Family**: Open Sans (OpenSans-Regular.ttf)
- **Body Text**: 14px
- **Headings**: Proportionally larger

## Bootstrap Components Used

- **Tables**: `.table`, `.table-striped`
- **Buttons**: `.btn`, `.btn-primary`, `.btn-success`, `.btn-warning`, `.btn-danger`, `.btn-sm`
- **Forms**: `.form-control`, `.form-label`, `.mb-3`
- **Cards**: `.card`, `.card-body`, `.card-title`
- **Alerts**: `.alert`, `.alert-info`, `.alert-success`, `.alert-danger`
- **Grid**: `.row`, `.col-md-6`

## Icons

Open Iconic icons are used throughout:
- `oi-home`: Home
- `oi-list`: Categories
- `oi-list-rich`: Items
- `oi-data-transfer-download`: Export/Import
- `oi-document`: Report
- `oi-spreadsheet`: Excel Definition

## Responsive Design

The application is designed to work on:
- Desktop Windows (primary target)
- Resizable window (minimum 768px width recommended)
- Sidebar collapses on smaller screens (< 768px)

## Interaction Patterns

1. **List Pages**: Display data in tables with Edit/Delete buttons
2. **Forms**: Inline forms appear above the list when adding/editing
3. **Success Messages**: Green alert boxes at the top of forms
4. **Error Messages**: Red alert boxes with error details
5. **Loading States**: "Loading..." text or disabled buttons during operations

## Expected User Flow

```
1. User opens application
   → Home page displays with database status

2. User navigates to Categories
   → Sees list of 3 seed categories
   → Clicks "Add New Category"
   → Form appears with Code and Name fields
   → Fills form and clicks "Save"
   → Success message appears
   → Table refreshes with new category

3. User navigates to Items
   → Sees list of 3 seed items with categories
   → Clicks "Add New Item"
   → Form appears with all fields including Category combobox
   → Selects category from dropdown (populated from database)
   → Fills other fields and clicks "Save"
   → Success message appears
   → Table refreshes with new item

4. User navigates to Export/Import
   → Sees export location path
   → Clicks "Export Now"
   → Success message with ZIP file path
   → Can copy file to another location
   → Can import by entering ZIP path

5. User navigates to Report
   → Sees template path and status
   → Understands this is ready for actual implementation

6. User navigates to Excel Definition
   → Clicks "Load Definition"
   → Sees parsed table and column definitions
   → Understands database schema
```

## Notes for Screenshots

When taking actual screenshots on Windows:

1. Ensure application is built and running
2. Navigate to each page
3. Capture initial state and form states
4. Show success/error messages
5. Demonstrate Category combobox in Items form
6. Show Export success message
7. Display Excel definition content

This visual guide provides the expected UI layout and functionality for the MAUI Blazor Hybrid Windows Sample application.
