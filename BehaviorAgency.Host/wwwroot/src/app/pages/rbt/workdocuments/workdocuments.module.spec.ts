import { WorkdocumentsModule } from './workdocuments.module';

describe('WorkdocumentsModule', () => {
  let workdocumentsModule: WorkdocumentsModule;

  beforeEach(() => {
    workdocumentsModule = new WorkdocumentsModule();
  });

  it('should create an instance', () => {
    expect(workdocumentsModule).toBeTruthy();
  });
});
