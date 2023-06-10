namespace Integracao
{
    partial class Configuracoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtRefreshToken = new TextBox();
            txtAccessToken = new TextBox();
            label1 = new Label();
            btnAutorizarApi = new Button();
            grpAccessToken = new GroupBox();
            grpChaveAcesso = new GroupBox();
            grpRefreshToken = new GroupBox();
            txtClienteId = new TextBox();
            grpClientId = new GroupBox();
            txtChaveSecreta = new TextBox();
            btnCriarPasta = new Button();
            grpIdPasta = new GroupBox();
            txtIdPasta = new TextBox();
            txtNomeAplicativo = new TextBox();
            grpNomeAplicativo = new GroupBox();
            txtEmail = new TextBox();
            grpEmail = new GroupBox();
            grpConfigAcesso = new GroupBox();
            grpChaveSecreta = new GroupBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            txtDescrArq = new TextBox();
            txtTpArq = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNomeArq = new TextBox();
            txtCaminArq = new TextBox();
            btnEnviarArq = new Button();
            btnAttDados = new Button();
            grpAccessToken.SuspendLayout();
            grpChaveAcesso.SuspendLayout();
            grpRefreshToken.SuspendLayout();
            grpClientId.SuspendLayout();
            grpIdPasta.SuspendLayout();
            grpNomeAplicativo.SuspendLayout();
            grpEmail.SuspendLayout();
            grpConfigAcesso.SuspendLayout();
            grpChaveSecreta.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRefreshToken
            // 
            txtRefreshToken.Location = new Point(6, 22);
            txtRefreshToken.Name = "txtRefreshToken";
            txtRefreshToken.Size = new Size(555, 23);
            txtRefreshToken.TabIndex = 1;
            // 
            // txtAccessToken
            // 
            txtAccessToken.Location = new Point(6, 22);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.Size = new Size(555, 23);
            txtAccessToken.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(43, 193);
            label1.Name = "label1";
            label1.Size = new Size(494, 15);
            label1.TabIndex = 4;
            label1.Text = "Atenção: Para realizar a ativação da API é preciso informar o arquivo Json com as credenciais";
            // 
            // btnAutorizarApi
            // 
            btnAutorizarApi.Location = new Point(239, 146);
            btnAutorizarApi.Name = "btnAutorizarApi";
            btnAutorizarApi.Size = new Size(78, 45);
            btnAutorizarApi.TabIndex = 3;
            btnAutorizarApi.Text = "Autorizar API";
            btnAutorizarApi.UseVisualStyleBackColor = true;
            btnAutorizarApi.Click += btnAutorizarApi_Click;
            // 
            // grpAccessToken
            // 
            grpAccessToken.Controls.Add(txtAccessToken);
            grpAccessToken.Location = new Point(6, 84);
            grpAccessToken.Name = "grpAccessToken";
            grpAccessToken.Size = new Size(567, 56);
            grpAccessToken.TabIndex = 2;
            grpAccessToken.TabStop = false;
            grpAccessToken.Text = "Access Token";
            // 
            // grpChaveAcesso
            // 
            grpChaveAcesso.Controls.Add(label1);
            grpChaveAcesso.Controls.Add(btnAutorizarApi);
            grpChaveAcesso.Controls.Add(grpAccessToken);
            grpChaveAcesso.Controls.Add(grpRefreshToken);
            grpChaveAcesso.Location = new Point(6, 292);
            grpChaveAcesso.Name = "grpChaveAcesso";
            grpChaveAcesso.Size = new Size(579, 215);
            grpChaveAcesso.TabIndex = 3;
            grpChaveAcesso.TabStop = false;
            grpChaveAcesso.Text = "Chaves de Acesso";
            // 
            // grpRefreshToken
            // 
            grpRefreshToken.Controls.Add(txtRefreshToken);
            grpRefreshToken.Location = new Point(6, 22);
            grpRefreshToken.Name = "grpRefreshToken";
            grpRefreshToken.Size = new Size(567, 56);
            grpRefreshToken.TabIndex = 2;
            grpRefreshToken.TabStop = false;
            grpRefreshToken.Text = "Refresh Token";
            // 
            // txtClienteId
            // 
            txtClienteId.Location = new Point(6, 22);
            txtClienteId.Name = "txtClienteId";
            txtClienteId.Size = new Size(555, 23);
            txtClienteId.TabIndex = 1;
            // 
            // grpClientId
            // 
            grpClientId.Controls.Add(txtClienteId);
            grpClientId.Location = new Point(6, 22);
            grpClientId.Name = "grpClientId";
            grpClientId.Size = new Size(567, 56);
            grpClientId.TabIndex = 0;
            grpClientId.TabStop = false;
            grpClientId.Text = "Client Id";
            // 
            // txtChaveSecreta
            // 
            txtChaveSecreta.Location = new Point(6, 22);
            txtChaveSecreta.Name = "txtChaveSecreta";
            txtChaveSecreta.Size = new Size(555, 23);
            txtChaveSecreta.TabIndex = 1;
            // 
            // btnCriarPasta
            // 
            btnCriarPasta.Location = new Point(483, 14);
            btnCriarPasta.Name = "btnCriarPasta";
            btnCriarPasta.Size = new Size(78, 36);
            btnCriarPasta.TabIndex = 2;
            btnCriarPasta.Text = "Criar";
            btnCriarPasta.UseVisualStyleBackColor = true;
            btnCriarPasta.Click += btnCriarPasta_Click;
            // 
            // grpIdPasta
            // 
            grpIdPasta.Controls.Add(btnCriarPasta);
            grpIdPasta.Controls.Add(txtIdPasta);
            grpIdPasta.Location = new Point(6, 146);
            grpIdPasta.Name = "grpIdPasta";
            grpIdPasta.Size = new Size(567, 56);
            grpIdPasta.TabIndex = 2;
            grpIdPasta.TabStop = false;
            grpIdPasta.Text = "Id Pasta";
            // 
            // txtIdPasta
            // 
            txtIdPasta.Location = new Point(6, 22);
            txtIdPasta.Name = "txtIdPasta";
            txtIdPasta.Size = new Size(471, 23);
            txtIdPasta.TabIndex = 1;
            // 
            // txtNomeAplicativo
            // 
            txtNomeAplicativo.Location = new Point(6, 22);
            txtNomeAplicativo.Name = "txtNomeAplicativo";
            txtNomeAplicativo.Size = new Size(287, 23);
            txtNomeAplicativo.TabIndex = 1;
            // 
            // grpNomeAplicativo
            // 
            grpNomeAplicativo.Controls.Add(txtNomeAplicativo);
            grpNomeAplicativo.Location = new Point(6, 208);
            grpNomeAplicativo.Name = "grpNomeAplicativo";
            grpNomeAplicativo.Size = new Size(298, 56);
            grpNomeAplicativo.TabIndex = 3;
            grpNomeAplicativo.TabStop = false;
            grpNomeAplicativo.Text = "Nome Aplicativo";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(6, 22);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(251, 23);
            txtEmail.TabIndex = 1;
            // 
            // grpEmail
            // 
            grpEmail.Controls.Add(txtEmail);
            grpEmail.Location = new Point(310, 208);
            grpEmail.Name = "grpEmail";
            grpEmail.Size = new Size(263, 56);
            grpEmail.TabIndex = 4;
            grpEmail.TabStop = false;
            grpEmail.Text = "Email";
            // 
            // grpConfigAcesso
            // 
            grpConfigAcesso.Controls.Add(grpEmail);
            grpConfigAcesso.Controls.Add(grpNomeAplicativo);
            grpConfigAcesso.Controls.Add(grpIdPasta);
            grpConfigAcesso.Controls.Add(grpChaveSecreta);
            grpConfigAcesso.Controls.Add(grpClientId);
            grpConfigAcesso.Location = new Point(6, 11);
            grpConfigAcesso.Name = "grpConfigAcesso";
            grpConfigAcesso.Size = new Size(579, 275);
            grpConfigAcesso.TabIndex = 2;
            grpConfigAcesso.TabStop = false;
            grpConfigAcesso.Text = "Configurações de Acesso";
            // 
            // grpChaveSecreta
            // 
            grpChaveSecreta.Controls.Add(txtChaveSecreta);
            grpChaveSecreta.Location = new Point(6, 84);
            grpChaveSecreta.Name = "grpChaveSecreta";
            grpChaveSecreta.Size = new Size(567, 56);
            grpChaveSecreta.TabIndex = 2;
            grpChaveSecreta.TabStop = false;
            grpChaveSecreta.Text = "Chave Secreta";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtDescrArq);
            groupBox1.Controls.Add(txtTpArq);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNomeArq);
            groupBox1.Controls.Add(txtCaminArq);
            groupBox1.Controls.Add(btnEnviarArq);
            groupBox1.Location = new Point(591, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 252);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Upload Arquivo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 154);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 13;
            label4.Text = "Descrição Arquivo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 108);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 12;
            label5.Text = "Tipo Arquivo";
            // 
            // txtDescrArq
            // 
            txtDescrArq.Location = new Point(6, 172);
            txtDescrArq.Name = "txtDescrArq";
            txtDescrArq.Size = new Size(188, 23);
            txtDescrArq.TabIndex = 11;
            // 
            // txtTpArq
            // 
            txtTpArq.Location = new Point(6, 126);
            txtTpArq.Name = "txtTpArq";
            txtTpArq.Size = new Size(188, 23);
            txtTpArq.TabIndex = 10;
            txtTpArq.Text = "PDF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 65);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 9;
            label3.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 8;
            label2.Text = "Caminho Arquivo";
            // 
            // txtNomeArq
            // 
            txtNomeArq.Location = new Point(6, 83);
            txtNomeArq.Name = "txtNomeArq";
            txtNomeArq.Size = new Size(188, 23);
            txtNomeArq.TabIndex = 7;
            // 
            // txtCaminArq
            // 
            txtCaminArq.Location = new Point(6, 37);
            txtCaminArq.Name = "txtCaminArq";
            txtCaminArq.Size = new Size(188, 23);
            txtCaminArq.TabIndex = 6;
            // 
            // btnEnviarArq
            // 
            btnEnviarArq.Location = new Point(6, 201);
            btnEnviarArq.Name = "btnEnviarArq";
            btnEnviarArq.Size = new Size(188, 44);
            btnEnviarArq.TabIndex = 5;
            btnEnviarArq.Text = "Enviar";
            btnEnviarArq.UseVisualStyleBackColor = true;
            btnEnviarArq.Click += btnEnviarArq_Click;
            // 
            // btnAttDados
            // 
            btnAttDados.Location = new Point(591, 281);
            btnAttDados.Name = "btnAttDados";
            btnAttDados.Size = new Size(200, 56);
            btnAttDados.TabIndex = 5;
            btnAttDados.Text = "Atribuir valores as propriedades";
            btnAttDados.UseVisualStyleBackColor = true;
            btnAttDados.Click += btnAttDados_Click;
            // 
            // Configuracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 514);
            Controls.Add(btnAttDados);
            Controls.Add(groupBox1);
            Controls.Add(grpChaveAcesso);
            Controls.Add(grpConfigAcesso);
            Name = "Configuracoes";
            Text = "Configuracoes";
            grpAccessToken.ResumeLayout(false);
            grpAccessToken.PerformLayout();
            grpChaveAcesso.ResumeLayout(false);
            grpChaveAcesso.PerformLayout();
            grpRefreshToken.ResumeLayout(false);
            grpRefreshToken.PerformLayout();
            grpClientId.ResumeLayout(false);
            grpClientId.PerformLayout();
            grpIdPasta.ResumeLayout(false);
            grpIdPasta.PerformLayout();
            grpNomeAplicativo.ResumeLayout(false);
            grpNomeAplicativo.PerformLayout();
            grpEmail.ResumeLayout(false);
            grpEmail.PerformLayout();
            grpConfigAcesso.ResumeLayout(false);
            grpChaveSecreta.ResumeLayout(false);
            grpChaveSecreta.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtRefreshToken;
        private TextBox txtAccessToken;
        private Label label1;
        private Button btnAutorizarApi;
        private GroupBox grpAccessToken;
        private GroupBox grpChaveAcesso;
        private GroupBox grpRefreshToken;
        private TextBox txtClienteId;
        private GroupBox grpClientId;
        private TextBox txtChaveSecreta;
        private Button btnCriarPasta;
        private GroupBox grpIdPasta;
        private TextBox txtIdPasta;
        private TextBox txtNomeAplicativo;
        private GroupBox grpNomeAplicativo;
        private TextBox txtEmail;
        private GroupBox grpEmail;
        private GroupBox grpConfigAcesso;
        private GroupBox grpChaveSecreta;
        private GroupBox groupBox1;
        private Button btnEnviarArq;
        private Label label4;
        private Label label5;
        private TextBox txtDescrArq;
        private TextBox txtTpArq;
        private Label label3;
        private Label label2;
        private TextBox txtNomeArq;
        private TextBox txtCaminArq;
        private Button btnAttDados;
    }
}