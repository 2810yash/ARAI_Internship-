using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SaveBO
    {
        private int _FEEDBACKREQUESTID;
        private string _ASSESSE;
        private string _ASSESSOR;

        private DateTime _date_of_incident;
        private DateTime _time_of_incident;
        private string _name_of_affected_person;
        private string _name_of_department;
        private string _location_of_incident;
        private string _nature_of_incident;
        private string _drop_down_1;
        private string _drop_down_2;
        private string _drop_down_3;
        private string _drop_down_4;
        private string _drop_down_5;
        private string _drop_down_6;
        private string _describe_incident;
        private string _immediate_action_taken;
        private string _root_cause_analysis;
        private string _corrective_action_plan;
        private DateTime _completion_date;
        private string _responsible_person;
        private string _corrective_action_impact;
        private Boolean _hazard_study;
        private string _FName;
        private string _FExtension;
        private string _FilePath;
        private string _FileAttachment;
        private string _IPaddress;

        public DateTime date_of_incident
        {
            get
            {
                return _date_of_incident;
            }
            set
            {
                _date_of_incident = value;
            }
        }
        public DateTime time_of_incident
        {
            get
            {
                return _time_of_incident;
            }
            set
            {
                _time_of_incident = value;
            }
        }
        public string name_of_affected_person
        {
            get
            {
                return string.IsNullOrEmpty(_name_of_affected_person) ? "NULL" : _name_of_affected_person;
            }
            set
            {
                _name_of_affected_person = value;
            }
        }
        public string name_of_department
        {
            get
            {
                return string.IsNullOrEmpty(_name_of_department) ? "NULL" : _name_of_department;
            }
            set
            {
                _name_of_department = value;
            }
        }
        public string location_of_incident
        {
            get
            {
                return string.IsNullOrEmpty(_location_of_incident) ? "NULL" : _location_of_incident;
            }
            set
            {
                _location_of_incident = value;
            }
        }
        public string nature_of_incident
        {
            get
            {
                return string.IsNullOrEmpty(_nature_of_incident) ? "NULL" : _nature_of_incident;
            }
            set
            {
                _nature_of_incident = value;
            }
        }
        public string drop_down_1
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_1) ? "NULL" : _drop_down_1;
            }
            set
            {
                _drop_down_1 = value;
            }
        }
        public string drop_down_2
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_2) ? "NULL" : _drop_down_2;
            }
            set
            {
                _drop_down_2 = value;
            }
        }
        public string drop_down_3
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_3) ? "NULL" : _drop_down_3;
            }
            set
            {
                _drop_down_3 = value;
            }
        }
        public string drop_down_4
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_4) ? "NULL" : _drop_down_4;
            }
            set
            {
                _drop_down_4 = value;
            }
        }
        public string drop_down_5
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_5) ? "NULL" : _drop_down_5;
            }
            set
            {
                _drop_down_5 = value;
            }
        }
        public string drop_down_6
        {
            get
            {
                return string.IsNullOrEmpty(_drop_down_6) ? "NULL" : _drop_down_6;
            }
            set
            {
                _drop_down_6 = value;
            }
        }
        public string describe_incident
        {
            get
            {
                return string.IsNullOrEmpty(_describe_incident) ? "NULL" : _describe_incident;
            }
            set
            {
                _describe_incident = value;
            }
        }
        public string immediate_action_taken
        {
            get
            {
                return string.IsNullOrEmpty(_immediate_action_taken) ? "NULL" : _immediate_action_taken;
            }
            set
            {
                _immediate_action_taken = value;
            }
        }
        public string root_cause_analysis
        {
            get
            {
                return string.IsNullOrEmpty(_root_cause_analysis) ? "NULL" : _root_cause_analysis;
            }
            set
            {
                _root_cause_analysis = value;
            }
        }
        public string corrective_action_plan
        {
            get
            {
                return string.IsNullOrEmpty(_corrective_action_plan) ? "NULL" : _corrective_action_plan;
            }
            set
            {
                _corrective_action_plan = value;
            }
        }
        public DateTime completion_date
        {
            get
            {
                return _completion_date;
            }
            set
            {
                _completion_date = value;
            }
        }
        public string responsible_person
        {
            get
            {
                return string.IsNullOrEmpty(_responsible_person) ? "NULL" : _responsible_person;
            }
            set
            {
                _responsible_person = value;
            }
        }
        public string corrective_action_impact
        {
            get
            {
                return string.IsNullOrEmpty(_corrective_action_impact) ? "NULL" : _corrective_action_impact;
            }
            set
            {
                _corrective_action_impact = value;
            }
        }
        public Boolean hazard_study
        {
            get
            {
                return _hazard_study;
            }
            set
            {
                _hazard_study = value;
            }
        }
        public string FName
        {
            get
            {
                return string.IsNullOrEmpty(_FName) ? "NULL" : _FName;
            }
            set
            {
                _FName = value;
            }
        }
        public string FExtension
        {
            get
            {
                return string.IsNullOrEmpty(_FExtension) ? "NULL" : _FExtension;
            }
            set
            {
                _FExtension = value;
            }
        }
        public string FilePath
        {
            get
            {
                return string.IsNullOrEmpty(_FilePath) ? "NULL" : _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }
        public string FileAttachment
        {
            get
            {
                return string.IsNullOrEmpty(_FileAttachment) ? "NULL" : _FileAttachment;
            }
            set
            {
                _FileAttachment = value;
            }
        }
        public string IPaddress
        {
            get
            {
                return string.IsNullOrEmpty(_IPaddress) ? "NULL" : _IPaddress;
            }
            set
            {
                _IPaddress = value;
            }
        }

        public string ASSESSE
        {
            get
            {
                return string.IsNullOrEmpty(_ASSESSE) ? "NULL" : _ASSESSE;
            }
            set
            {
                _ASSESSE = value;
            }
        }
        public string ASSESSOR
        {
            get
            {
                return string.IsNullOrEmpty(_ASSESSOR) ? "NULL" : _ASSESSOR;
            }
            set
            {
                _ASSESSOR = value;
            }
        }
    }
}
